using CarProject.Logic;

namespace CarProject.UnitTests;

[TestClass]
public class TrackBuilderTest
{

  [TestMethod]
  public void ItShouldBuildAConnectedTrack_GivenSectionInformation()
  {
    (int, int)[ ] sectionInfos = [ (10, 10) , (20, 20) , (30, 30) ];

    TrackBuilder builder = new(sectionInfos);

    Section
      startSection = new(sectionInfos[ 0 ].Item1 , sectionInfos[ 0 ].Item2),
      secondSection = new(sectionInfos[ 1 ].Item1 , sectionInfos[ 1 ].Item2),
      thirdSection = new(sectionInfos[ 2 ].Item1 , sectionInfos[ 2 ].Item2);

    startSection.AddAfterMe(secondSection);
    secondSection.AddAfterMe(thirdSection);
    Track manuallyBuiltTrack = new([ startSection , secondSection , thirdSection ]);

    Assert.AreEqual(10 , manuallyBuiltTrack.StartSection!.Length);
    Assert.AreEqual(10 , manuallyBuiltTrack.StartSection.MaxSpeed);
    Assert.AreEqual(startSection , manuallyBuiltTrack.StartSection);
    Assert.AreEqual(secondSection , manuallyBuiltTrack.StartSection.NextSection);

    Assert.AreEqual(10 , builder.RaceTrack!.StartSection!.Length);
    Assert.AreEqual(10 , builder.RaceTrack.StartSection.MaxSpeed);

    Assert.AreEqual(manuallyBuiltTrack.StartSection.Length , builder.RaceTrack.StartSection.Length);
    Assert.AreEqual(manuallyBuiltTrack.StartSection.MaxSpeed , builder.RaceTrack.StartSection.MaxSpeed);
    Assert.AreEqual(manuallyBuiltTrack.StartSection.NextSection!.Length , builder.RaceTrack.StartSection.NextSection!.Length);
    Assert.AreEqual(manuallyBuiltTrack.StartSection.NextSection.MaxSpeed , builder.RaceTrack.StartSection.NextSection.MaxSpeed);
    Assert.AreEqual(manuallyBuiltTrack.StartSection.NextSection.NextSection!.Length , builder.RaceTrack.StartSection.NextSection.NextSection!.Length);
    Assert.AreEqual(manuallyBuiltTrack.StartSection.NextSection.NextSection.MaxSpeed , builder.RaceTrack.StartSection.NextSection.NextSection.MaxSpeed);
  }

  [TestMethod]
  public void ItShouldConnectTheLastSegmentToTheFirst_GivenAnAdditionalParameterForALoopedTrack()
  {
    (int, int)[ ] sectionInfos = [ (10, 10) , (30, 30) ];

    TrackBuilder builder = new(sectionInfos , trackShallLoop: true);

    Assert.AreEqual(true , builder.RaceTrack!.LoopedTrack);
  }
    [TestMethod]
    public void TrackBuilder_ShouldCreateTrackAndLinkSections_GivenValidSectionInfo()
    {

        var sectionInfo = new List<(int, int)>
    {
        (50, 300), 
        (70, 500), 
        (60, 200)   
    };

        TrackBuilder builder = new TrackBuilder(sectionInfo.ToArray());

        Track track = builder.RaceTrack;

        Assert.IsNotNull(track); 
        Assert.AreEqual(1000, track.GetTotalLength()); 

        Assert.AreEqual(track.StartSection.NextSection.Length, 500); 
    }

}
