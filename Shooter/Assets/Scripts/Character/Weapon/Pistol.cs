public class Pistol : Weapon
{
    public override void Attack()
    {
        StartAttackDelay();
    }

    public override bool TryAttack()
    {
        if (CanAttack == false)
        {
            return false;
        }
        if (Input.Attachment.Attack.IsPressed() == false)
        {
            return false;
        }

        Attack();

        return true;
    }
}
