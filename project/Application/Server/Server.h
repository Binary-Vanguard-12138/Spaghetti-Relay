#pragma once
#include "../platform.h"
#include "../definitions.h"

class Server
{
	public:

	int init(uint16_t port);
	int readMessage(char* buffer, int32_t size);
	int sendMessage(char* data, int32_t length);
	void stop();

};