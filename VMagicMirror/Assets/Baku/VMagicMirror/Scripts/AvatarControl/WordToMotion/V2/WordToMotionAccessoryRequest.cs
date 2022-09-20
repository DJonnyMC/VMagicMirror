using UniRx;

namespace Baku.VMagicMirror.WordToMotion
{
    public class WordToMotionAccessoryRequest
    {
        private readonly ReactiveProperty<string> _accessoryRequest = new ReactiveProperty<string>("");
        public IReadOnlyReactiveProperty<string> AccessoryRequest => _accessoryRequest;

        public void SetAccessoryRequest(string fileId) => _accessoryRequest.Value = fileId;
        public void Reset() => SetAccessoryRequest("");
    }
}
