## Installation

Add the following line to `Packages/manifest.json`:

```json
"com.virtuesky.firebasedebugviewios": "https://github.com/unity-package/firebase-debugview-ios.git#1.0.0",
```

## Usage

Supported on iOS devices only. Use the following API to enable or disable Firebase DebugView:

```csharp
using VirtueSky.DebugView;

FirebaseDebugViewIOS.Enable();  // Enable DebugView
FirebaseDebugViewIOS.Disable(); // Disable DebugView
```

After enabling or disabling DebugView, force-close and relaunch the app, then check events in Firebase Console > Analytics > DebugView.
