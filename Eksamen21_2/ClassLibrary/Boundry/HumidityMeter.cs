using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry;
public class HumidityMeter : IHumidityMeter
{
    private int _humidity; 

    public HumidityMeter() {
        _humidity = 0;
    }
    public int GetHumidity() 
    {
        return _humidity;
    }
    public void SetHumidity(int humidity) {
        _humidity = humidity;
    }
}

   