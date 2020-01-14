function printDayOfWeek(dayOfWeek) {
    let dayOfWeekAsNumber = 0;
    switch (dayOfWeek) {
        case 'Monday':
            dayOfWeekAsNumber = 1;
            break;
        case 'Tuesday':
            dayOfWeekAsNumber = 2;
            break;
        case 'Wednesday':
            dayOfWeekAsNumber = 3;
            break;
        case 'Thursday':
            dayOfWeekAsNumber = 4;
            break;
        case 'Friday':
            dayOfWeekAsNumber = 5;
            break;
        case 'Saturday':
            dayOfWeekAsNumber = 6;
            break;
        case 'Sunday':
            dayOfWeekAsNumber = 7;
            break;
        default:
            dayOfWeekAsNumber = 'error';
            break;
    }

    console.log(dayOfWeekAsNumber);
}

printDayOfWeek(1);