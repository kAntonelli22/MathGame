

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

    public override string ToString()
    {
        string formatedString = $"\nTotal Time: {this.time} \t Average Time Per Question: {this.avgTime} \t Number of Questions: {questions.Count}\n";
        for (int i = 0; i < questions.Count; i++)
        {
            formatedString += string.Format($"{questions[i]} {times[i].ToString().PadLeft(60)}\n");
        }
        return formatedString;
    }
}