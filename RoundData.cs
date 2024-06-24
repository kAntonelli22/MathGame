

public class RoundData
{
    public List<string> questions;
    public List<TimeSpan> times;
    public double time;
    public double avgTime;

    public RoundData(List<string> questions, List<TimeSpan> times)
    {
        this.questions = questions;
        this.times = times;
        foreach (TimeSpan time in times) 
        {
            this.time += time.TotalSeconds;
        }
        this.avgTime = this.time / times.Count;
    }
}