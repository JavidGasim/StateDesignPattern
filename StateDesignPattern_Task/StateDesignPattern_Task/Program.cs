namespace StateDesignPattern_Task;

interface LightState
{
    void Handle(Light context);
}

class OnState : LightState
{
    public void Handle(Light context)
    {
        Console.WriteLine("Light is already ON");
    }
}

class OffState : LightState
{
    public void Handle(Light context)
    {
        Console.WriteLine("Turning ON the light");
        context.SetState(new OnState());
    }
}

class Light
{
    private LightState currentState;

    public Light()
    {
        currentState = new OffState();
    }

    public void SetState(LightState state)
    {
        currentState = state;
    }

    public void PressSwitch()
    {
        currentState.Handle(this);
    }
}

class Program
{
    static void Main()
    {
        Light light = new Light();

        light.PressSwitch(); 

        light.PressSwitch(); 
    }
}
