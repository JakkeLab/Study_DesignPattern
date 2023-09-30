namespace StructureComposite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Shape triangle = new Triangle();
            Shape circle = new Circle();
            Shape square = new Square();

            Drawing drawing = new Drawing();
            drawing.AddShape(triangle);
            drawing.AddShape(circle);
            drawing.AddShape(square);

            drawing.FillColor("빨간색");

            List<Shape> shapes = new List<Shape>();
            shapes.Add(drawing);
            shapes.Add(new Triangle());
            shapes.Add(new Circle());

            foreach(Shape shape in shapes)
            {
                shape.FillColor("초록색");
            }
        }
    }

    //그림판에 삼각형, 사각형 등 도형을 만들고 모두 빨간색으로 칠한다 가정
    //우선 Shape을 구현 후 색을 칠하는 메소드 정의
    public interface Shape
    {
        public void FillColor(String paintColor);
    }

    public class Triangle : Shape
    {
        public void FillColor(string paintColor)
        {
            Console.WriteLine($"삼각형이 다음 색으로 채워졌습니다 :  + {paintColor}");
        }
    }

    public class Square : Shape
    {
        public void FillColor(string paintColor)
        {
            Console.WriteLine($"사각형이 다음 색으로 채워졌습니다 :  + {paintColor}");
        }
    }
    public class Circle : Shape
    {
        public void FillColor(string paintColor)
        {
            Console.WriteLine($"원이 다음 색으로 채워졌습니다 :  + {paintColor}");
        }
    }

    //Drawing에서 FillColor을 실행한 경우 Drawing 내의 전체 Shape 객체들에 대해 FillColor가 되도록 함.
    public class Drawing : Shape
    {
        private List<Shape> shapes = new List<Shape>();

        public void FillColor(string paintColor)
        {
            foreach(Shape shape in shapes)
            {
                shape.FillColor(paintColor);
            }
        }

        public void AddShape(Shape s)
        {
            this.shapes.Add(s);
        }

        public void RemoveShape(Shape s)
        {
            this.shapes.Remove(s);
        }

        public void ClearShapes()
        {
            Console.WriteLine("모든 도형을 제거합니다.");
            this.shapes.Clear();
        }
        /* 요약 : 그림판에 여러 도형을 칠하는 기능과, 각각을 칠하는 기능을 모두 구현해야 할 때 같은 '칠하기' 기능으로 구현하도록 하는 것
           참고 : https://velog.io/@newtownboy/%EB%94%94%EC%9E%90%EC%9D%B8%ED%8C%A8%ED%84%B4-%EC%BB%B4%ED%8D%BC%EC%A7%80%ED%8A%B8%ED%8C%A8%ED%84%B4Composite-Pattern*/
    }


}