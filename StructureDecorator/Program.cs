namespace StructureDecorator
{
    public class Program
    {
        /* 시나리오 : 커피를 만든다고 가정*/
        static void Main(string[] args)
        {
            Console.WriteLine("커피를 만들어 봅시다.");
            Component espresso = new BaseComponent();
            Console.WriteLine("에스프레소 만들기 : " + espresso.add());

            Component americano = new WaterDecorator(new BaseComponent());
            Console.WriteLine("아메리카노 만들기 : " + americano.add());

            Component latte = new MilkDecorator(new WaterDecorator(new BaseComponent()));
            Console.WriteLine("라떼 만들기 : " + latte.add());
        }
    }

    //커피 재료를 추가하기 위한 함수
    public abstract class Component
    {
        public abstract string add();   //재료 추가하기
    }

    //커피의 기본재료가 되는 에스프레소를 미리 넣어두는것
    public class BaseComponent : Component
    {
        public override string add()
        {
            return "에스프레소";
        }
    }

    //커피 재료들의 기본이 되는 추상클래스
    public abstract class Decorator : Component
    {
        private Component coffeeComponent;

        public Decorator(Component coffeeComponent)
        {
            this.coffeeComponent = coffeeComponent;
        }
        public override string add()
        {
            return coffeeComponent.add();
        }
    }

    public class WaterDecorator : Decorator
    {
        public WaterDecorator(Component coffeeComponent) : base(coffeeComponent)
        {

        }

        public override string add()
        {
            return base.add() + " + 물";
        }
    }

    public class MilkDecorator : Decorator
    {
        public MilkDecorator(Component coffeeComponent) : base(coffeeComponent)
        {

        }

        public override string add()
        {
            return base.add() + " + 우유";
        }
    }
}

/* 출처 : https://coding-factory.tistory.com/713 
         내용 참고하여 C#으로 제작 */