ИНСТРУКЦИЯ ПО РАЗВЕРТЫВАНИЮ ДИПЛОМНОЙ РАБОТЫ

1. Копируем репозиторий Git
В командной строке Git bash введите команду git clone https://github.com/RassadinDan/CRM-system

2. В репозитории три папки с проектами
SkillProfiWebAPI
SkillProfiWebClient
SkillProfiDesctopClient

Чтобы развернуть WebAPI нужно перейти по пути ./SkillProfiWebAPI/SkillProfiWebAPI и ввести команду dotnet run.
Запустится API сервис, через которое клиентские приложения смогут обращаться к базе данных.

Для запуска клиентских приложений используется та же команда, вызванная из ./SkillProfiWebClient/SkillProfiWebClient 
или ./SkillProfiDesctopClient/SkillProfiDesctopClient соответственно.

Для входа с правами администратора в базе есть пользователь с логином и паролем admin, а для гостей логин и пароль
guest.