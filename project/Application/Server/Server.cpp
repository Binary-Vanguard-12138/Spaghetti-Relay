#include "Server.h"

int Server::init(uint16_t port)
{
	return SHUTDOWN;
}
int Server::readMessage(char* buffer, int32_t size)
{
	return SHUTDOWN;
}
int Server::sendMessage(char* data, int32_t length)
{
	return SHUTDOWN;
}
void Server::stop()
{

}