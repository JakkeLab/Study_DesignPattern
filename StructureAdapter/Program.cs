namespace StructureAdapter
{
    /* 어댑터 패턴 */
    public class Program
    {
        //로봇 작동부분
        static void Main(string[] args)
        {
            Console.WriteLine("기존 로봇을 작동합니다.\n");
            RobotSystem robot = new RobotSystem(new Arm(), new Arm());
            robot.armUp();
            robot.armDown();

            Console.WriteLine("신제품 팔을 왼팔로 교체하고 작동합니다.\n");
            RobotSystem newRobot = new RobotSystem(new Arm(), new NewArmAdapter());
            newRobot.armUp();
            newRobot.armDown();
        }
    }

    //로봇을 만든다 가정
    public interface ArmCore
    {
        public abstract void Up();
        public abstract void Down();
    }

    public class Arm : ArmCore
    {
        public void Down()
        {
            Console.WriteLine("Robot arm Down");
        }

        public void Up()
        {
            Console.WriteLine("Robot arm Up");
        }
    }

    public class RobotSystem
    {
        private ArmCore rightArm;
        private ArmCore leftArm;

        public RobotSystem(ArmCore rightArm, ArmCore leftArm)
        {
            this.rightArm = rightArm;
            this.leftArm = leftArm;
        }

        public void armUp()
        {
            rightArm.Up();
            leftArm.Up();
        }

        public void armDown()
        {
            rightArm.Down();
            leftArm.Down();
        }
    }

    //왼쪽 팔만 신제품으로 바꿔달라는 요구 발생시
    public class NewArm
    {
        public NewArm()
        {
            Console.WriteLine("Make New Robot Arm");
        }

        public void lift()
        {
            Console.WriteLine("New Robot Arm lift");
        }
        public void fall()
        {
            Console.WriteLine("New Robot Arm fall");
        }
    }

    /*신제품 팔을 장착하기 위한 어탭터 클래스. 
     * ArmCore를 구현하지 않으면 생성자에서 매개변수로 사용 불가능하다.*/
    public class NewArmAdapter : NewArm, ArmCore
    {
        public NewArmAdapter()
        {

        }
        public void Down()
        {
            base.fall();
        }

        public void Up()
        {
            base.lift();
        }
    }

    /*출처 : https://devmoony.tistory.com/76 */
}