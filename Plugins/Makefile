SRC = ObjectiveCNative.m
CC = clang
CFLAGS = -g -O0 -fno-objc-arc
FRAMEWORKS = -framework Foundation

ObjectiveCNative.o: ObjectiveCNative.m
	$(CC) $^ $(CFLAGS) -c -o $@

ObjectiveCNative.dylib: ObjectiveCNative.o
	$(CC) $^ $(CFLAGS) $(FRAMEWORKS) -shared -o $@