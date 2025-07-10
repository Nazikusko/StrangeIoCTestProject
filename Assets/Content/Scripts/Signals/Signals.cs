
using strange.extensions.signal.impl;

public class StartGameSignal : Signal { }
public class ExitGameSignal : Signal { }
public class BallLostSignal : Signal { }
public class BrickHitSignal : Signal<BrickViewBase> { }
public class ScoreChangedSignal : Signal<int> { }
public class LivesChangedSignal : Signal<int> { }
public class StartGamePlaySignal : Signal { }
