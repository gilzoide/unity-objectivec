#import "Foundation/Foundation.h"

id Gilzoide_ObjectiveC_NSInvocationInvoke(id invocation) {
    @try {
        [invocation invoke];
        return nil;
    }
    @catch (NSException *exception) {
        return exception;
    }
}