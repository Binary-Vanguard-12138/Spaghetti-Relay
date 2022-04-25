#pragma once
#include "../platform.h"
#include "../definitions.h"

class Server
{
private:
	SOCKET m_sServerSocket;
	SOCKET m_sClientSocket;

public:
	Server();
	int init(uint16_t port);
	int readMessage(char* buffer, int32_t size);
	int sendMessage(char* data, int32_t length);
	void stop();

};