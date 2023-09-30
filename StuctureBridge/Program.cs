using System.Security.Cryptography.X509Certificates;

namespace StuctureBridge
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("브리지 패턴 : 사냥법 설계\n");

            
            Animal fish = new Fish(new HuntingMethodFish());
            Animal deer = new Deer(new HuntingMethodDeer());

            Console.WriteLine("물고기 잡기");
            fish.HuntQuarry();
            Console.WriteLine("---------");
            Console.WriteLine("사슴 잡기");
            deer.HuntQuarry();
        }
    }

    /* 시나리오 : 동물과 동물을 사냥할 수 있는 방법을 각각 정의하여 짜는 것*/

    #region Abstraction 부분
    //최상위 클래스
    public interface HuntingHandler
    {
        public void FindQuarry();
        public void DetectedQuarry();
        public void Attack();
    }

    //물고기 잡는법 클래스
    public class HuntingMethodFish : HuntingHandler
    {
        public void Attack()
        {
            Console.WriteLine("사냥법 : 낚시대로 낚는다.");
        }

        public void DetectedQuarry()
        {
            Console.WriteLine("강에서 물고기를 찾았다.");
        }

        public void FindQuarry()
        {
            Console.WriteLine("강가로 가서 찾아본다.");
        }
    }

    //사슴 잡는법 클래스
    public class HuntingMethodDeer : HuntingHandler
    {
        public void Attack()
        {
            Console.WriteLine("사냥법 : 엽총으로 쏜다.");
        }

        public void DetectedQuarry()
        {
            Console.WriteLine("수풀에서 사슴 발견.");
        }

        public void FindQuarry()
        {
            Console.WriteLine("들판을 둘러본다.");
        }
    }
    #endregion


    //구현 인터페이스 정의
    public class Animal
    {
        private HuntingHandler hunting;

        public Animal(HuntingHandler hunting)
        {
            this.hunting = hunting;
        }

        public void FindQuarry()
        {
            hunting.FindQuarry();
        }

        public void DetectedQuarry()
        {
            hunting.DetectedQuarry();
        }

        public void Attack()
        {
            hunting.Attack();
        }

        public void HuntQuarry()
        {
            FindQuarry();
            DetectedQuarry();
            Attack();
        }
    }

    //실제 동물로 구현
    public class Fish : Animal
    {
        public Fish(HuntingHandler hunting) : base(hunting)
        {
            
        }

        public void hunt()
        {
            Console.WriteLine("물고기 사냥법");
            FindQuarry();
            DetectedQuarry();
            Attack();
        }
    }

    public class Deer : Animal
    {
        public Deer(HuntingHandler hunting) : base(hunting)
        {

        }

        public void hunt()
        {
            Console.WriteLine("노루 사냥법");
            FindQuarry();
            DetectedQuarry();
            Attack();
        }
    }

    /* 요약 : 기능 클래스와 구현 클래스 구조로 구분하고, 클래스 사이를 연결하는 역할 브리지가 수행한다.
     *       여기서 브리지는 Animal 속의 HuntingHandler hunting이 담당하게 된다.
     */
}