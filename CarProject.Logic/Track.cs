namespace CarProject.Logic;

public class Track
{
    #region field
    private readonly List<Section> _trackList;
    private readonly bool _loopedTrack;
    private readonly bool _isEmptyTrack;
    #endregion

    #region constructor
    public Track(List<Section>? trackList, bool trackShallLoop = false)
    {
        if (trackList == null || trackList.Count == 0)
            throw new ArgumentNullException(nameof(trackList), "Sections cant be empty");

        _trackList = trackList;
        _loopedTrack = trackShallLoop;
        _isEmptyTrack = false;

        for (int i = 0; i < _trackList.Count - 1; i++)
        {
            _trackList[i].AddAfterMe(_trackList[i + 1]);
        }

        if (_loopedTrack && _trackList.Count > 1)
            _trackList.Last().AddAfterMe(_trackList.First());
    }
    private Track()
    {
        _trackList = new List<Section>();
        _loopedTrack = false;
        _isEmptyTrack = true;  
    }
    #endregion

    #region properties
    public Section? StartSection => _trackList.Count > 0 ? _trackList.First() : null;

    public int GetTotalLength
    {
        get
        {
            if (StartSection == null) return 0;  

            int result = 0;

            foreach (var section in _trackList)
                result += section.Length;

            return result;
        }
    }

    public int GetMaxSpeed
    {
        get
        {
            if (StartSection == null) return 0; 

            int result = 0;

            foreach (var section in _trackList)
                if (section.MaxSpeed > result)
                    result = section.MaxSpeed;

            return result;
        }
    }

    public bool LoopedTrack => _loopedTrack;
    #endregion

    public bool IsEmpty()
    {
        return _isEmptyTrack;
    }
    public static Track CreateEmptyTrack()
    {
        return new Track();
    }
    public void Debug_PrintSection(int index)
    {
        if (_isEmptyTrack)
        {
            Console.WriteLine("Your Track is empty");
            return;
        }
        if (index == -1)
        {
            for(int i = 0; i < _trackList.Count; i++)
            {
                Debug_PrintSection(i);
                return;
            }
        }
        if (index >= _trackList.Count || index < 0)
        {
            Console.WriteLine("Index out of Range");
            return;
        }
        Console.WriteLine(_trackList[index].ToString());
    }
}