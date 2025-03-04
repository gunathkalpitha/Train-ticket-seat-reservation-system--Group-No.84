using System;
using System.Collections.Generic;
using System.Diagnostics;

class Train_s
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string StartLocation { get; set; }
    public string EndLocation { get; set; }
    public TimeSpan StartTime { get; set; }
    public string ArrivalTime { get; set; }

    public Train_s(string name, string type, string startLocation, string endLocation, string startTime, string arrivalTime)
    {
        Name = name;
        Type = type;
        StartLocation = startLocation;
        EndLocation = endLocation;
        StartTime = DateTime.Parse(startTime).TimeOfDay;
        ArrivalTime = arrivalTime;
    }
}

class TrainSchedule
{
    public List<Train_s> Trains { get; set; }

    public TrainSchedule()
    {
        Trains = new List<Train_s>
        {
            new  Train_s("Train 1", "Express", "Beliatta", "Maradana", "4:15 AM", "8:30 AM"),
            new Train_s("Train 2", "Slow", "Beliatta", "Matara", "7:20 AM", "8:00 AM"),
            new  Train_s("Train 3", "Express", "Maradana", "Beliatta", "9:20 AM", "2:30 PM"),
            new  Train_s("Train 4", "Slow", "Matara", "Beliatta", "10:20 AM", "10:55 AM")
        };
    }

    public void BubbleSort()
    {
        int n = Trains.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (Trains[j].StartTime > Trains[j + 1].StartTime)
                {
                    (Trains[j], Trains[j + 1]) = (Trains[j + 1], Trains[j]);
                }
            }
        }
    }

    public void MergeSortTrains()
    {
        MergeSort(Trains, 0, Trains.Count - 1);
    }

    private void MergeSort(List<Train_s> trains, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(trains, left, mid);
            MergeSort(trains, mid + 1, right);
            Merge(trains, left, mid, right);
        }
    }

    private void Merge(List<Train_s> trains, int left, int mid, int right)
    {
        List<Train_s> leftArray = trains.GetRange(left, mid - left + 1);
        List<Train_s> rightArray = trains.GetRange(mid + 1, right - mid);

        int x = 0, y = 0, k = left;
        while (x < leftArray.Count && y < rightArray.Count)
        {
            if (leftArray[x].StartTime <= rightArray[y].StartTime)
                trains[k++] = leftArray[x++];
            else
                trains[k++] = rightArray[y++];
        }
        while (x < leftArray.Count)
            trains[k++] = leftArray[x++];
        while (y < rightArray.Count)
            trains[k++] = rightArray[y++];
    }

    public void QuickSortTrains(int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(Trains, low, high);
            QuickSortTrains(low, partitionIndex - 1);
            QuickSortTrains(partitionIndex + 1, high);
        }
    }

    private int Partition(List<Train_s> trains, int low, int high)
    {
        TimeSpan pivot = trains[high].StartTime;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (trains[j].StartTime <= pivot)
            {
                i++;
                (trains[i], trains[j]) = (trains[j], trains[i]);
            }
        }
        (trains[i + 1], trains[high]) = (trains[high], trains[i + 1]);
        return i + 1;
    }

    public void DisplayTrains()
    {
        foreach (var train in Trains)
        {
            Console.WriteLine($" {train.Name} | {train.Type} | {train.StartLocation} -> {train.EndLocation} | Departs: {train.StartTime} | Arrives: {train.ArrivalTime}");
        }
    }
}



