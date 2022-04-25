#include "Client.h"

int Client::init(uint16_t port, char* address)
{
	return SHUTDOWN;
}
int Client::readMessage(char* buffer, int32_t size)
{
	return SHUTDOWN;
}
int Client::sendMessage(char* data, int32_t length)
{
	return SHUTDOWN;
}
void Client::stop()
{

}