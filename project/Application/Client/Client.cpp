#include "Client.h"
#include <WS2tcpip.h>

Client::Client() {
	m_sClientSocket = INVALID_SOCKET;
}

int Client::init(uint16_t port, char* address)
{
	int nRet = SHUTDOWN;
	SOCKET sCliSocket = INVALID_SOCKET;
	struct sockaddr_in tTcpSvrAddr = {}, tTcpClientAddr = {};
	int nTcpClientAddrLen = sizeof(tTcpClientAddr);
	int err = startup();

	if (0 != err) {
		goto end;
	}
	tTcpSvrAddr.sin_family = AF_INET;
	err = inet_pton(AF_INET, address, &tTcpSvrAddr.sin_addr);
	tTcpSvrAddr.sin_port = htons(port);
	if (0 >= err) {
		nRet = ADDRESS_ERROR;
		goto end;
	}

	sCliSocket = socket(AF_INET, SOCK_STREAM, 0);
	if (INVALID_SOCKET == sCliSocket) {
		nRet = SETUP_ERROR;
		goto end;
	}

	err = connect(sCliSocket, (struct sockaddr*)&tTcpSvrAddr, sizeof(tTcpSvrAddr));
	if (SOCKET_ERROR == err) {
		nRet = CONNECT_ERROR;
		close(sCliSocket);
		goto end;
	}

	nRet = SUCCESS;
	m_sClientSocket = sCliSocket;

end:
	return nRet;
}

int Client::readMessage(char* buffer, int32_t size)
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

int Client::sendMessage(char* data, int32_t length)
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

void Client::stop()
{
	if (INVALID_SOCKET != m_sClientSocket) {
		shutdown(m_sClientSocket, SD_BOTH);
		close(m_sClientSocket);
		m_sClientSocket = INVALID_SOCKET;
	}
	shutdown();
}