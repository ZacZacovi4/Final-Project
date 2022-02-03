using System;
using System.Collections.Generic;
using System.Text;
using general_test.Functions.AttributeChangeOperations;

namespace general_test.Functions
{
    class AttributeChange
    {
        private readonly ILogger logger;
        private AddOrRemoveHidden addOrRemoveHidden;
        private AddOrRemoveReadOnly addOrRemoveReadOnly;
        private ShowAttribute showAttribute;

        public AttributeChange(ILogger logger)
        {
            this.logger = logger;
            addOrRemoveHidden = new AddOrRemoveHidden(logger);
            addOrRemoveReadOnly = new AddOrRemoveReadOnly(logger);
            showAttribute = new ShowAttribute(logger);
        }
        public void AttributeChangeChoisMenu()
        {
            logger.ShowMessage($@" Выберите какую процедуру вы хотите выполнить (для выбора введите цифру варианта)
1. Показать свойства файла. 
2. Добавить свойсто Hidden. 
3. Убрать свойсто Hidden. 
4. Добавить свойсто ReadOnly.
5. Убрать свойсто ReadOnly.  
q - для выхода в главное меню. ");
        }

        public void AttributeChangeFunctions()
        {
            AttributeChangeChoisMenu();
            string switchKey;
            while (true)
            {
                switchKey = Console.ReadLine().ToLower();
                switch (switchKey)
                {
                    case "1":
                        Console.Clear();
                        showAttribute.ShowAttributes();
                        break;

                    case "2":
                        Console.Clear();
                        addOrRemoveHidden.SetAttributeHidden();
                        break;

                    case "3":
                        Console.Clear();
                        addOrRemoveHidden.RemoveAttributeHidden();
                        break;

                    case "4":
                        Console.Clear();
                        addOrRemoveReadOnly.SetAttributeReadOnly();
                        break;

                    case "5":
                        Console.Clear();
                        addOrRemoveReadOnly.RemoveAttributeReadOnly();
                        break;

                    case "q":
                        return;

                    default:
                        Console.Clear();
                        logger.ShowMessage($"Ошибка ввода, введите пожалуйста символ функции, которую хотите использовать.");
                        AttributeChangeChoisMenu();
                        break;
                }
            }
        }
    }
}
