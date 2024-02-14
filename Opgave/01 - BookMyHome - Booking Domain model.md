# 01 - BookMyHome - Booking Domain model

Opgaven løses vha Domain Centric Architecture

## Opgave:
Domain laget for Booking - incl. test - implementeres.
Der er følgende domæne regler:
- Man kan ikke booke i fortiden.
- Booking sker på dato - dvs. uden tidspunkt.
- En booking er fra og med startdato til og med slutdato
- Slutdato skal ligge efter startdato
- Der må ikke være overlappende bookings. Dvs.
	- Ved opret og ret skal det tjekkes at der ikke opstår overlappende bookings. Sker det skal der kastes en Custom exception - "OverlapingBookingException"