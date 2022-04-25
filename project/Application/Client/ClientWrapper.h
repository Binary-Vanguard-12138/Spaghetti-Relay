#ifndef _CLIENT_WRAPPER_H_
#define _CLIENT_WRAPPER_H_

#include "../platform.h"
#include "../definitions.h"

EXPORTED int init(uint16_t port, char* address);
EXPORTED int readMessage(char* buffer, int32_t size);
EXPORTED int sendMessage(char* data, int32_t length);
EXPORTED void stop();

#endif
