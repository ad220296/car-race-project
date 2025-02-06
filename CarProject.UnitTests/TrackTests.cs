using CarProject.Logic;

namespace CarProject.UnitTests;

[TestClass]
public class TrackTests
{

  [TestMethod]
  public void ItShouldSaveTheStartSectionOfATrack_GivenAnyNumbersOfSections()
  {
    Section
      startSection = new(50 , 300),
      middleSection = new(70 , 500),
      lastSection = new(60 , 200);
    List<Section> trackList = [ startSection , middleSection , lastSection ];

    Track track = new(trackList);

    Assert.AreEqual(startSection , track.StartSection);
  }

  [TestMethod]
  public void ItShouldReturnTotalLength_GivenMultipleSections()
  {
    Section
      startSection = new(50 , 300),
      middleSection = new(70 , 500),
      lastSection = new(60 , 200);
    List<Section> trackList = [ startSection , middleSection , lastSection ];

    Track track = new(trackList);

    Assert.AreEqual(1000 , track.GetTotalLength);
  }

  [TestMethod]
  public void ItShouldReturnMaxSpeed_GivenMultipleSections()
  {
    Section
      startSection = new(50 , 300),
      middleSection = new(70 , 500),
      lastSection = new(60 , 200);
    List<Section> trackList = [ startSection , middleSection , lastSection ];

    Track track = new(trackList);

    Assert.AreEqual(70 , track.GetMaxSpeed);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException) , "Sections cant be empty")]
  public void ItShouldThrowException_GivenEmptySectionList()
  {
    List<Section> sectionList = [ ];
    Track track = new(sectionList);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException) , "Sections cant be empty")]
  public void ItShouldThrowException_GivenNullSectionList()
  {
    List<Section>? sectionList = null;
    Track track = new(sectionList);
  }

  [TestMethod]
  public void ItShouldConnectTheLastSegmentToTheFirst_GivenAnAdditionalParameterForALoopedTrack()
  {
    Section
      startSection = new(50 , 300),
      middleSection = new(70 , 500),
      lastSection = new(60 , 200);
    List<Section> trackList = [ startSection , middleSection , lastSection ];

    Track track = new(trackList , trackShallLoop: true);

    Assert.AreEqual(startSection , lastSection.NextSection);
  }

    [TestMethod]
    public void IsEmptyTrack_ShouldReturnTrue_GivenNoSections()
    {
        Track track = Track.CreateEmptyTrack();

        bool isEmpty = track.IsEmpty();

        Assert.IsTrue(isEmpty);
    }

}