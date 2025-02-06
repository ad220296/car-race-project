namespace CarProject.Logic;

public class TrackBuilder
{
    #region field
    private readonly Track? _track;
    #endregion

    #region property
    public Track? RaceTrack => _track;
  #endregion

  #region constructor
  public TrackBuilder((int, int)[ ] sectionInfos , bool trackShallLoop = false)
  {
        List<Section> allSections = new List<Section>();
        Section? lastSection = null;

        foreach (var section in sectionInfos)
        {
            Section newSection = new Section(section.Item1, section.Item2);

            if (lastSection != null)
            {
                lastSection.AddAfterMe(newSection);
            }

            lastSection = newSection;
            allSections.Add(newSection);
        }
        _track = new Track(allSections , trackShallLoop);
  }
  #endregion
}
