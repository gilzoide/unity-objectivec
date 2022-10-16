#import "Foundation/Foundation.h"

id Gilzoide_ObjectiveC_NSInvocationProtectedInvoke(id invocation) {
    @try {
        [invocation invoke];
        return nil;
    }
    @catch (NSException *exception) {
        return exception;
    }
}

struct block {
    void *isa; // initialized to &_NSConcreteStackBlock or &_NSConcreteGlobalBlock
    int flags;
    int reserved;
    void* invoke;
    struct block_descriptor {
        unsigned long int reserved;     // NULL
        unsigned long int size;         // sizeof(struct block)
    } *descriptor;
};
struct block_descriptor _descriptor = { 0, sizeof(struct block) };

void Gilzoide_ObjectiveC_BlockWithPointer(struct block* ret, void* functionPointer) {
    *ret = (struct block) { &_NSConcreteStackBlock, 0, 0, functionPointer, &_descriptor };
}