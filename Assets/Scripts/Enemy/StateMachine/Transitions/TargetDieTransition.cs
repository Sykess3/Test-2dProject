
public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (Target.gameObject.activeSelf == false)
            NeedTransit = true;
    }
}
