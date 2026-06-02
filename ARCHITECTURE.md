# 🏗️ ARCHITECTURE - Архитектура проекта

## 📐 Общая структура

```
PhysicsTesting/
│
├── Models/                    # Модели данных
│   ├── Question.cs
│   ├── Student.cs
│   └── TestResult.cs
│
├── Services/                  # Бизнес-логика
│   ├── TestManager.cs
│   └── DatabaseManager.cs
│
├── Forms/                     # Пользовательский интерфейс
│   ├── MainForm.cs
│   ├── TestForm.cs
│   ├── ResultsForm.cs
│   └── ResultsDetailForm.cs
│
├── Program.cs                 # Точка входа
└── PhysicsTesting.csproj     # Конфигурация
```

## 🧩 Компоненты системы

### 1️⃣ Models (Модели данных)

#### `Question.cs` - Модель вопроса

```csharp
public class Question
{
    public int Id { get; set; }                      // Уникальный ID
    public string Text { get; set; }                 // Текст вопроса
    public List<string> Answers { get; set; }        // 4 варианта ответов
    public int CorrectAnswerIndex { get; set; }      // Индекс правильного ответа (0-3)
    public string Topic { get; set; }                // Название темы
}
```

**Использование:** Представление одного вопроса в памяти приложения

#### `Student.cs` - Модель ученика

```csharp
public class Student
{
    public int Id { get; set; }                      // ID ученика
    public string FullName { get; set; }             // Полное имя
    public List<TestResult> Results { get; set; }    // История результатов
}
```

**Использование:** Хранение информации об ученике и его результатах

#### `TestResult.cs` - Модель результата теста

```csharp
public class TestResult
{
    public int Id { get; set; }                      // ID результата
    public string StudentName { get; set; }          // ФИО ученика
    public string Topic { get; set; }                // Тема теста
    public int CorrectAnswers { get; set; }          // Количество правильных ответов
    public int TotalQuestions { get; set; }          // Общее количество вопросов
    public double Percentage { get; set; }           // Процент выполнения
    public int Grade { get; set; }                   // Выставленная оценка
    public DateTime Date { get; set; }               // Дата и время прохождения
    public TimeSpan Duration { get; set; }           // Длительность теста
}
```

**Использование:** Сохранение и отображение результатов теста

### 2️⃣ Services (Сервисы)

#### `TestManager.cs` - Управление тестами

**Ответственность:**
- ✅ Загрузка всех вопросов (55 шт.)
- ✅ Извлечение списка тем
- ✅ Инициализация теста для выбранной темы
- ✅ Случайная выборка 10 вопросов
- ✅ Перемешивание вариантов ответов
- ✅ Проверка ответов
- ✅ Подсчет результатов
- ✅ Вычисление оценок

**Основные методы:**

```csharp
public List<string> GetTopics()
// Возвращает список всех доступных тем

public void StartTest(string topic)
// Инициализирует новый тест для выбранной темы

public Question GetCurrentQuestion()
// Возвращает текущий вопрос

public bool HasNextQuestion()
// Проверяет, остались ли вопросы

public void SelectAnswer(int answerIndex)
// Регистрирует выбранный ответ и проверяет его

public int GetCorrectAnswersCount()
// Возвращает количество правильных ответов

public double GetPercentage()
// Вычисляет процент выполнения

public int CalculateGrade(double percentage)
// Выставляет оценку по 10-балльной системе
```

**База данных вопросов:**

55 вопросов по 11 темам (5 вопросов на тему):

```csharp
private List<Question> GetDefaultQuestions()
{
    var questions = new List<Question>
    {
        // 5 вопросов: Введение в физику
        new(1, "Что такое физика?", ..., "Введение в физику"),
        ...
        // 5 вопросов: Физические величины и измерения
        new(6, "Какая система единиц используется?", ..., "Физические величины и измерения"),
        ...
        // И так далее для всех 11 тем
    };
}
```

#### `DatabaseManager.cs` - Управление базой данных

**Ответственность:**
- ✅ Инициализация SQLite БД
- ✅ Создание таблиц
- ✅ Сохранение результатов
- ✅ Загрузка результатов
- ✅ Фильтрация и поиск
- ✅ Удаление результатов

**Основные методы:**

```csharp
public void InitializeDatabase()
// Создает БД и необходимые таблицы

public void SaveTestResult(TestResult result)
// Сохраняет результат теста в БД

public List<TestResult> GetAllResults()
// Загружает все результаты

public List<TestResult> GetResultsByStudent(string studentName)
// Загружает результаты конкретного ученика

public List<TestResult> GetResultsByTopic(string topic)
// Загружает результаты по теме

public void DeleteResult(int resultId)
// Удаляет результат из БД
```

**Структура БД:**

```sql
CREATE TABLE TestResults (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentName TEXT NOT NULL,
    Topic TEXT NOT NULL,
    CorrectAnswers INTEGER NOT NULL,
    TotalQuestions INTEGER NOT NULL,
    Percentage REAL NOT NULL,
    Grade INTEGER NOT NULL,
    Date TEXT NOT NULL,
    Duration TEXT NOT NULL
)
```

### 3️⃣ Forms (Пользовательский интерфейс)

#### `MainForm.cs` - Главное окно

**Элементы интерфейса:**
- TextBox для ввода ФИО ученика
- ComboBox для выбора темы
- Button "Начать тест"
- Button "Просмотр результатов"
- Button "Выход"

**Логика:**
```csharp
// При загрузке
- Загружаются все доступные темы в ComboBox

// При нажатии "Начать тест"
- Проверяется ввод ФИО и выбор темы
- Создается новое окно TestForm
- Передаются параметры: имя ученика, тема, менеджеры

// При нажатии "Просмотр результатов"
- Открывается окно ResultsForm со всеми результатами

// При нажатии "Выход"
- Приложение закрывается
```

#### `TestForm.cs` - Окно тестирования

**Элементы интерфейса:**
- Label для номера вопроса
- Label для текста вопроса
- 4 RadioButton для ответов
- Button "Далее"/"Завершить"
- ProgressBar для прогресса
- Label для таймера
- Timer для отсчета времени

**Логика:**

```csharp
// Инициализация
- Запускается тест для выбранной темы
- Загружается первый вопрос
- Запускается таймер

// На каждом вопросе
- Отображается текст и варианты ответов
- Пользователь выбирает ответ (RadioButton)
- При нажатии "Далее":
  * Проверяется, выбран ли ответ
  * Регистрируется выбор в TestManager
  * Проверяется правильность ответа
  * Загружается следующий вопрос (если есть)

// На последнем вопросе
- Кнопка меняется на "Завершить"
- При нажатии "Завершить":
  * Останавливается таймер
  * Создается объект TestResult
  * Результат сохраняется в БД
  * Открывается окно ResultsDetailForm
```

#### `ResultsDetailForm.cs` - Окно результатов теста

**Элементы интерфейса:**
- Label со всей информацией о результате
- Button "Закрыть"

**Отображаемая информация:**
- ФИО ученика
- Тема теста
- Количество правильных ответов (X/10)
- Процент выполнения
- Выставленная оценка (с цветовой индикацией)
- Время прохождения

#### `ResultsForm.cs` - Окно просмотра результатов

**Элементы интерфейса:**
- DataGridView для отображения таблицы результатов
- TextBox для поиска по фамилии
- ComboBox для фильтрации по теме
- Button "Поиск"
- Button "Очистить"
- Button "Удалить"
- Button "Закрыть"

**Логика:**

```csharp
// При загрузке
- Загружаются все темы в ComboBox
- Отображаются все результаты в таблице

// При нажатии "Поиск"
- Проверяется ввод в TextBox поиска
- Вызывается GetResultsByStudent
- Таблица обновляется с найденными результатами

// При выборе темы в ComboBox
- Можно фильтровать результаты по теме

// При нажатии "Очистить"
- Очищается поле поиска
- Сбрасывается фильтр
- Отображаются все результаты

// При нажатии "Удалить"
- Проверяется, выбрана ли строка
- Показывается подтверждение
- Результат удаляется из БД
- Таблица обновляется
```

## 🔄 Потоки выполнения (Use Cases)

### Use Case 1: Прохождение теста

```
┌─────────────────┐
│   Главное окно  │
│                 │
│ Ввод ФИО        │
│ Выбор темы      │
│ Нажать "Начать" │
└────────┬────────┘
         │
         ▼
┌──────────────────────┐
│   Инициализация      │
│                      │
│ TestManager.         │
│  StartTest(topic)    │
│                      │
│ Загружаются 10 вопр. │
│ Перемешиваются ответ │
└────────┬─────────────┘
         │
         ▼
┌──────────────────────┐
│  Окно тестирования   │
│                      │
│ Загрузка вопроса 1   │
│ Пользователь отвеч.  │
│ Проверка ответа      │
│ Загрузка вопроса 2   │
│ ... и т.д. до 10     │
└────────┬─────────────┘
         │
         ▼
┌──────────────────────┐
│   Завершение         │
│                      │
│ Подсчет результатов  │
│ Вычисление оценки    │
│ Сохранение в БД      │
│ Отображение итогов   │
└──────────────────────┘
```

### Use Case 2: Просмотр результатов

```
┌─────────────────────┐
│  Главное окно       │
│ "Просмотр результ." │
└────────┬────────────┘
         │
         ▼
┌─────────────────────┐
│  Окно результатов   │
│                     │
│ DatabaseManager.    │
│  GetAllResults()    │
│                     │
│ Загрузка всех данн. │
└────────┬────────────┘
         │
         ▼
┌─────────────────────┐
│  Таблица            │
│ результатов         │
└────────┬────────────┘
         │
    ┌────┴────┐
    │          │
    ▼          ▼
┌─────────┐ ┌──────────┐
│ Поиск   │ │Фильтр по │
│по ФИО   │ │теме      │
└─────────┘ └──────────┘
```

## 📊 Диаграмма классов

```
┌────────────────────────┐
│      Question          │
├────────────────────────┤
│ - Id: int              │
│ - Text: string         │
│ - Answers: List<str>   │
│ - CorrectAnswerIndex:i │
│ - Topic: string        │
└────────────────────────┘

┌────────────────────────┐
│      TestResult        │
├────────────────────────┤
│ - Id: int              │
│ - StudentName: string  │
│ - Topic: string        │
│ - CorrectAnswers: int  │
│ - TotalQuestions: int  │
│ - Percentage: double   │
│ - Grade: int           │
│ - Date: DateTime       │
│ - Duration: TimeSpan   │
└────────────────────────┘

┌────────────────────────┐
│      Student           │
├────────────────────────┤
│ - Id: int              │
│ - FullName: string     │
│ - Results: List<TestR> │
└────────────────────────┘

┌─────────────────────────┐
│     TestManager         │
├─────────────────────────┤
│ - _allQuestions: List   │
│ - _currentTestQuestions │
│ - _currentQuestionIndex │
│ - _correctAnswersCount  │
├─────────────────────────┤
│ + LoadQuestions()       │
│ + GetTopics()           │
│ + StartTest(topic)      │
│ + GetCurrentQuestion()  │
│ + HasNextQuestion()     │
│ + SelectAnswer(index)   │
│ + CalculateGrade(%)     │
└─────────────────────────┘

┌──────────────────────────┐
│   DatabaseManager        │
├──────────────────────────┤
│ - _connectionString: str │
│ - _dbPath: string        │
├──────────────────────────┤
│ + SaveTestResult(result) │
│ + GetAllResults()        │
│ + GetByStudent(name)     │
│ + GetByTopic(topic)      │
│ + DeleteResult(id)       │
└──────────────────────────┘
```

## 🔐 Безопасность и валидация

### Валидация входных данных

```csharp
// MainForm - проверка ввода перед началом теста
if (string.IsNullOrWhiteSpace(txtFullName.Text))
    MessageBox.Show("Введите ФИО");

if (cmbTopic.SelectedItem == null)
    MessageBox.Show("Выберите тему");

// TestForm - проверка выбора ответа
if (selectedAnswer == -1)
    MessageBox.Show("Выберите ответ");
```

### Защита от ошибок

```csharp
try
{
    // Операции с БД
    _databaseManager.SaveTestResult(result);
}
catch (Exception ex)
{
    MessageBox.Show($"Ошибка: {ex.Message}");
}
```

## 🚀 Расширяемость

Система разработана с учетом возможности расширения:

### Добавление новых вопросов

Просто добавьте в `TestManager.GetDefaultQuestions()`:

```csharp
new(56, "Новый вопрос?", 
    new List<string> { "Ответ 1", "Ответ 2", "Ответ 3", "Ответ 4" }, 
    0, // Индекс правильного ответа
    "Имя темы")
```

### Добавление новых форм

1. Создайте новый класс, наследующий Form
2. Добавьте дизайнер (.Designer.cs)
3. Создайте код-бихайнд (.cs)
4. Используйте как диалоговое окно: `formName.ShowDialog()`

### Изменение системы оценивания

Отредактируйте метод `CalculateGrade` в `TestManager.cs`:

```csharp
public int CalculateGrade(double percentage)
{
    return percentage switch
    {
        < 20 => 1,
        < 41 => 2,
        < 61 => 3,
        // Измените пороги по необходимости
        _ => 10
    };
}
```

---

Архитектура проекта обеспечивает чистоту кода, модульность и лёгкость поддержки! 🎯

