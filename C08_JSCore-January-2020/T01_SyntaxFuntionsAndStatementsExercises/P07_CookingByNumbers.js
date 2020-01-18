function cookingByNumbers(commands) {
    let number = Number(commands[0]);
    let command = '';

    for (let index = 1; index < commands.length; index++) {
        command = String(commands[index]);

        switch (command) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number += 1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.80;
                break;
            default:
                break;
        }

        console.log(number);
    }
}

cookingByNumbers(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);