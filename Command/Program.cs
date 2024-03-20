namespace Command
{
    public struct Vec2
    {
        public int x;
        public int y;
    }
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public class PlayerMover
    {
        public Vec2 position;
        public void Move(Vec2 direction)
        {
            position.x += direction.x;
            position.y += direction.y;
        }

    }

    public class MoveCommand : ICommand
    {
        private PlayerMover _playerMover;
        private int _x;
        private int _y;

        public MoveCommand(PlayerMover playerMover, int x, int y)
        {
            _playerMover = playerMover;
            _x = x;
            _y = y;
        }

        public void Execute()
        {
            _playerMover.Move(new Vec2 { x = _x, y = _y });
        }

        public void Undo()
        {
            _playerMover.Move(new Vec2 { x = -_x, y = -_y });
        }
    }

    public class InputHandler
    {

        public Stack<ICommand> _commands = new Stack<ICommand>();


        private PlayerMover _playerMover;

        public InputHandler(PlayerMover playerMover)
        {
            _playerMover = playerMover;
        }


        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commands.Push(command);
        }

        public void Undo()
        {
            if (_commands.Count > 0)
            {
                ICommand command = _commands.Pop();
                command.Undo();
            }
        }

        public void HandleInput(char input)
        {
            ICommand command;
            switch (input)
            {
                case 'w':
                    command = new MoveCommand(_playerMover, 0, 1);
                    break;
                case 's':
                    command = new MoveCommand(_playerMover, 0, -1);
                    break;
                case 'a':
                    command = new MoveCommand(_playerMover, -1, 0);
                    break;
                case 'd':
                    command = new MoveCommand(_playerMover, 1, 0);
                    break;
                case 'z':
                    Undo();
                    return;
                default:
                    return;
            }
            ExecuteCommand(command);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerMover playerMover = new PlayerMover();
            InputHandler inputHandler = new InputHandler(playerMover);
            while (true)
            {
                Console.Write("Enter a command: ");
                char input = Console.ReadKey().KeyChar;
                inputHandler.HandleInput(input);
                Console.WriteLine($" Player position: {playerMover.position.x}, {playerMover.position.y}");
            }

        }
    }
}
