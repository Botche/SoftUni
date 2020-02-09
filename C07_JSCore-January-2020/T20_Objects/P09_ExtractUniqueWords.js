function extractUniqueWords(input) {
    result = [];
    for (let index = 0; index < input.length; index++) {
        const element = input[index].split(/\W+/g).filter(x => x != '');
        
        element.forEach(word => {
            let wordLowerCase = word.toLowerCase();
            if (!result.includes(wordLowerCase)) {
                result.push(wordLowerCase);
            } 
        });
    };

    console.log(result.join(', '));
}

extractUniqueWords(['Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'Pellentesque quis hendrerit dui.', 
'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.', 
'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.', 
'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.', 
'Morbi in ipsum varius, pharetra diam vel, mattis arcu.', 
'Integer ac turpis commodo, varius nulla sed, elementum lectus.', 
'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.']
);