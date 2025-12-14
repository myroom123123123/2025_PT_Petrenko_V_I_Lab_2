# Education task Project example

## Способи створення проекту
Кожен проект який створюється на парах або самостійно має працбювати належним чином та бути правильно налаштованим  
Перед здачею проекту Ви маєте переконатись не лише в тому що у вас виконуються усі Юніт тести, а і в тому, що з вашим кодом все гаразд.
Це означає що в ньому **немає бути помилок під час компіляції а і усунуто усі варнинги**.


## Створення проекту самостійно
Ви можете створювати проект самостійно за допомогою 
* [консолі](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)  
* [VisualStudio](https://learn.microsoft.com/en-us/visualstudio/ide/create-new-project?view=vs-2022)  
* [Raider](https://www.jetbrains.com/help/rider/Creating_and_Opening_Projects_and_Solutions.html)  
* [VSCode](https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-8-0)  
Під час створення проекту необхідно одирати версію .NET8, як для самого проекту так і для Юніт тестів

Після створення проекту у ваш файли проектів (*.csproj) необхідно двідредагувати блок <PropertyGroup> щоб він виглядав так
```
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>NET8.0</TargetFramework>
    <EnableNETAnalyzers>true</EnableNETAnalyzers>
    <AnalysisMode>AllEnabledByDefault</AnalysisMode>
    <CodeAnalysisTreatWarningsAsErrors>false</CodeAnalysisTreatWarningsAsErrors>
    <NoWarn>SA0001,SA1633</NoWarn>
  </PropertyGroup>
  ```

Додати блок для налаштування **StyleCop**
  ```
  <ItemGroup>
    <AdditionalFiles Include="..\code-analysis.ruleset" Link="Properties\code-analysis.ruleset" />
    <AdditionalFiles Include="..\stylecop.json" Link="Properties\stylecop.json" />
  </ItemGroup>
```
та блок з налаштуванням версії **StyleCop**
```
  <ItemGroup>
    <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>
```




## Створення проекту на основі цього репозиторію
1. Завантажуємо цей проет як архів до себе на комп'ютер.  
2. Переносимо архів до робочого каталогу  
3. Розпаковуємо цей архив
4. Міняємо назву папки **EmptyTask** відповідно до вимог до файлів  
5. Переходимо до переіменованого каталогу.  
6. Переходимо на https://gitlab,.com створюємо там порожній репозиторій без Readme.md з такою самою назвою що і у пункті 4
7. Виконуємо ті команди що прописані на https://gitlab,.com  щоб запушити існуючий проект (Push an existing folder)  
8. Відкриваємо солюшен та реалізуємо протрібний функціонал.
9. Не переіменовуємо проекти що всередині.  
