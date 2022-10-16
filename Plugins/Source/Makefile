SRC = ObjectiveCNative.m
CC = clang
LIPO = lipo
CFLAGS = -fno-objc-arc
FRAMEWORKS = -framework Foundation

# macOS libraries (each arch + universal)
../macOS/ObjectiveCNative_x86_64.dylib~: CFLAGS += -isysroot '$(shell xcrun --sdk macosx --show-sdk-path)' -arch x86_64
../macOS/ObjectiveCNative_x86_64.dylib~: ObjectiveCNative.m
	$(CC) $^ $(CFLAGS) $(FRAMEWORKS) -shared -o $@

../macOS/ObjectiveCNative_arm64.dylib~: CFLAGS += -isysroot '$(shell xcrun --sdk macosx --show-sdk-path)' -arch arm64
../macOS/ObjectiveCNative_arm64.dylib~: ObjectiveCNative.m
	$(CC) $^ $(CFLAGS) $(FRAMEWORKS) -shared -o $@

../macOS/ObjectiveCNative.dylib: ../macOS/ObjectiveCNative_x86_64.dylib~ ../macOS/ObjectiveCNative_arm64.dylib~
	$(LIPO) $^ -create -output $@

# targets
osx: ../macOS/ObjectiveCNative.dylib

all: osx