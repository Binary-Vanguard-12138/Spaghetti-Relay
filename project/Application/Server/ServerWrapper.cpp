#include "ServerWrapper.h"
#include "./Server.h"

static Server server;

int init(uint16_t port)
{
	if (startup())
		return STARTUP_ERROR;

	return server.init(port);
	stop();
}

int readMessage(char* buffer, int32_t size)
{
	return server.readMessage(buffer, size);
}

int sendMessage(char* data, int32_t length)
{
	return server.sendMessage(data, length);
}

void stop()
{
	server.stop();
	shutdown();
}
