namespace CarProject.Logic;

public class Track
{
    #region field
    private readonly List<Section> _trackList;
    private readonly bool _loopedTrack;
    private bool _isEmptyTrack;
    #endregion

    #region constructor
    public Track(List<Section>? trackList, bool trackShallLoop = false)
    {
        if (trackList == null || trackList.Count == 0)
            throw new ArgumentNullException(nameof(trackList), "Sections cant be empty");

        _trackList = trackList;
        _loopedTrack = trackShallLoop;

        for (int i = 0; i < _trackList.Count - 1; i++)
        {
            _trackList[i].AddAfterMe(_trackList[i + 1]);
        }

        if (_loopedTrack)
            _trackList.Last().AddAfterMe(_trackList.First());
    }
    private Track()
    {
        _trackList = new List<Section>();
        _isEmptyTrack = true;  
    }
    #endregion

    #region properties
    public Section? StartSection { get => _trackList.FirstOrDefault(); }

    public int GetTotalLength()
    {
        int totalLength = 0;
        Section? current = _trackList.First();

        while (current != null)
        {
            totalLength += current.Length;
            current = current.NextSection;

            if (_loopedTrack && current == _trackList.First())
                break;
        }
        return totalLength;
    }

    public int GetMaxSpeed()
    {
        int maxSpeed = 0;
        Section? current = _trackList.First();

        while (current != null)
        {
            if (current.MaxSpeed > maxSpeed)
                maxSpeed = current.MaxSpeed;

            current = current.NextSection;

            if (_loopedTrack && current == _trackList.First())
                break;
        }
        return maxSpeed;
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
        if (_trackList.Count == 0)
            Console.WriteLine("Your Track is empty");
        else if (index == -1)
        {
            int i = 0;
            foreach (var section in _trackList)
                Debug_PrintSection(i++);
        }
        else if (index >= _trackList.Count || index < 0)
            Console.WriteLine("Index out of Range");
        else
            Console.WriteLine(_trackList[index].ToString());
    }
}