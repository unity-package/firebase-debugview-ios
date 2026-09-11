#import <Foundation/Foundation.h>

// These keys are Firebase Measurement implementation details. Keep this file
// isolated so the QA-only workaround can be removed without touching Firebase init.
extern "C"
{
    void DancingRoadEnableFirebaseDebugView()
    {
        NSUserDefaults *defaults = [NSUserDefaults standardUserDefaults];
        [defaults setBool:YES forKey:@"/google/firebase/debug_mode"];
        [defaults setBool:YES forKey:@"/google/measurement/debug_mode"];
        NSLog(@"[FirebaseDebugView] Enabled; restart the app to apply.");
    }

    void DancingRoadDisableFirebaseDebugView()
    {
        NSUserDefaults *defaults = [NSUserDefaults standardUserDefaults];
        [defaults removeObjectForKey:@"/google/firebase/debug_mode"];
        [defaults removeObjectForKey:@"/google/measurement/debug_mode"];
        NSLog(@"[FirebaseDebugView] Disabled; restart the app to apply.");
    }

    int DancingRoadIsFirebaseDebugViewEnabled()
    {
        return [[NSUserDefaults standardUserDefaults] boolForKey:@"/google/measurement/debug_mode"] ? 1 : 0;
    }
}
