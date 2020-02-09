function filtherEmployees(data, criteria) {
    let parseData = JSON.parse(data);

    if (criteria === 'all') {
        parseData.forEach((element, index) => {
            console.log(`${index}. ${element.first_name} ${element.last_name} - ${element.email}`)
        });
    } else {
        let [criteriaName, value] = criteria.split('-');

        let index = 0;
        parseData.forEach((element) => {

            if (element[criteriaName] == value) {
                console.log(`${index}. ${element.first_name} ${element.last_name} - ${element.email}`);
                index++;
            }
        });
    }
}

filtherEmployees(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`,
    'gender-Female'
)