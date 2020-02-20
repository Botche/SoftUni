function solve(arrayOfTickets, sortingCriteria){
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];
    for (let i = 0; i < arrayOfTickets.length; i++) {
        let ticket = arrayOfTickets[i];

        let [destination, price, status] = ticket.split('|');

        ticket = new Ticket(destination, +price, status);

        tickets.push(ticket);
    };

    switch (sortingCriteria) {
        case "destination":
            tickets = tickets.sort((a, b) => a.destination.localeCompare(b.destination));
            break;
        case "status":
            tickets = tickets.sort((a, b) => a.status.localeCompare(b.status));
            break;
        case "price":
            tickets = tickets.sort((a, b) => a.price - b.price);
            break;

        default:
            break;
    }


    return tickets;
}