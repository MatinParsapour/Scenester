using UnityEditor;

namespace Dastan.Scenester.Editor.util
{
    public class ProgressBarUtility
    {

        private const float DefaultValue = 0;
        private float _currentValue;
        private const float DefaultIncrementer = 10;
        private float _incrementer;
        private string _title;
        private string _info;
        
        public static ProgressBarUtility Initialize(string title, string info)
        {
            return new ProgressBarUtility(title, info);
        }

        public ProgressBarUtility(string title, string info)
        {
            _title = title;
            _info = info;
            _currentValue = DefaultValue;
            _incrementer = DefaultIncrementer;
            EditorUtility.DisplayProgressBar(_title, _info, _currentValue);
        }

        private void Progress(float progress)
        {
            EditorUtility.DisplayProgressBar(_title, _info, progress);
        }

        public ProgressBarUtility Progress()
        {
            _currentValue += _incrementer;
            Progress(_currentValue);
            return this;
        }

        public ProgressBarUtility SetIncrementer(float incrementer)
        {
            _incrementer = incrementer;
            return this;
        }

        public ProgressBarUtility SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public ProgressBarUtility SetInfo(string info)
        {
            _info = info;
            return this;
        }

        public ProgressBarUtility Done()
        {
            Progress(100);
            return this;
        }

        public ProgressBarUtility Clear()
        {
            EditorUtility.ClearProgressBar();
            return this;
        }
    }
}