# PhoneBook
# Technologies and Patterns
- .NET 6
- Docker
- Postgres
- CQRS
- Entity Framework Core - Code First
- RabbitMQ

======

Docker Desktop kurulu olmalıdır.

**docker-compose up -d** komutu ile ilgili veritabanı PostgreSql ve RabbitMQ ayağa kalkar.

PhoneBook.API ve Report.API projeleri solutions --> properties bölümünden multiple project olarak seçilir.
Proje başlatılır.

• Rehberde kişi oluşturma

• Rehberde kişi kaldırma

• Rehberdeki kişiye iletişim bilgisi ekleme

• Rehberdeki kişiden iletişim bilgisi kaldırma

• Rehberdeki kişilerin listelenmesi

• Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin
getirilmesi

• Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor
talebi

• Sistemin oluşturduğu raporların listelenmesi

• Sistemin oluşturduğu bir raporun detay bilgilerinin getirilmesi

servisleri yazılmıştır.

PhoneBook.API servisinde kişi oluşturulur, iletişim bilgileri eklenir.
Report.API servisinde rapor isteği başlatılır. RabbitMQ kuyruğa alır.

Report.API ve PhoneBook.API HTTP üzerinden haberleşir.

Tamamlanan raporlar rapor servisinden çekilir.





