#pragma once
#include "../platform.h"
#include "../definitions.h"

class Client
{
private:
	SOCKET m_sClientSocket;

public:
	Client();
	int init(uint16_t port, char* address);
	int readMessage(char* buffer, int32_t size);
	int sendMessage(char* data, int32_t length);
	void stop();
};