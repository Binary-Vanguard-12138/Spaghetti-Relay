#include "Server.h"

Server::Server() {
	m_sServerSocket = INVALID_SOCKET;
	m_sClientSocket = INVALID_SOCKET;
}

int Server::init(uint16_t port)
{
	int nRet = SHUTDOWN;
	SOCKET sSvrSocket = INVALID_SOCKET, sCliSocket = INVALID_SOCKET;
	struct sockaddr_in tTcpSvrAddr = {}, tTcpClientAddr = {};
	int nTcpClientAddrLen = sizeof(tTcpClientAddr);
	int err = startup();

	if (0 != err) {
		goto end;
	}
	sSvrSocket = socket(AF_INET, SOCK_STREAM, 0);
	if (INVALID_SOCKET == sSvrSocket) {
		nRet = SETUP_ERROR;
		goto end;
	}
	tTcpSvrAddr.sin_family = AF_INET;
	tTcpSvrAddr.sin_addr.s_addr = INADDR_ANY;
	tTcpSvrAddr.sin_port = htons(port);
	if (0 != bind(sSvrSocket, (struct sockaddr*) & tTcpSvrAddr, sizeof(tTcpSvrAddr))) {
		nRet = BIND_ERROR;
		close(sSvrSocket);
		goto end;
	}

	if (0 != listen(sSvrSocket, 5)) {
		nRet = SETUP_ERROR;
		close(sSvrSocket);
		goto end;
	}
	sCliSocket = accept(sSvrSocket, (struct sockaddr*) & tTcpClientAddr, &nTcpClientAddrLen);
	if (INVALID_SOCKET == sCliSocket) {
		nRet = CONNECT_ERROR;
		close(sSvrSocket);
		goto end;
	}
	nRet = SUCCESS;
	m_sServerSocket = sSvrSocket;
	m_sClientSocket = sCliSocket;

end:
	return nRet;
}
int Server::readMessage(char* buffer, int32_t size)
{
	char szBuffer[0x400] = {};
	if (NULL == buffer || 0 == size)
		return PARAMETER_ERROR;

	int nRecvLen = recv(m_sClientSocket, szBuffer, sizeof(szBuffer), 0);
	if (SOCKET_ERROR == nRecvLen) {
		return DISCONNECT;
	}
	else if (0 == nRecvLen) {
		return SHUTDOWN;
	}

	int nExpectedLen = (unsigned char)szBuffer[0];
	if (nRecvLen != nExpectedLen + 1 || size < nExpectedLen) {
		return PARAMETER_ERROR;
	}
	memset(buffer, 0, size);
	memcpy(buffer, szBuffer + 1, nExpectedLen);
	return SUCCESS;
}

int Server::sendMessage(char* data, int32_t length)
{
	if (0 > length || 255 < length)
		return PARAMETER_ERROR;
	char szBuffer[0x100] = {};
	szBuffer[0] = length;
	memcpy(szBuffer + 1, data, length);
	int nSentLen = send(m_sClientSocket, szBuffer, 1 + length, 0);
	if (SOCKET_ERROR == nSentLen)
		return DISCONNECT;
	else if (0 == nSentLen)
		return SHUTDOWN;

	return SUCCESS;
}
void Server::stop()
{
	if (INVALID_SOCKET != m_sClientSocket) {
		shutdown(m_sClientSocket, SD_BOTH);
		close(m_sClientSocket);
		m_sClientSocket = INVALID_SOCKET;
	}
	if (INVALID_SOCKET != m_sServerSocket) {
		shutdown(m_sServerSocket, SD_BOTH);
		close(m_sServerSocket);
		m_sServerSocket = INVALID_SOCKET;
	}
	shutdown();
}