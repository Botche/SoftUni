function usernames(input) {
    let uniqueNames = new Set(input);

    let result = [...uniqueNames].sort((a,b) => a.length - b.length || a.localeCompare(b));

    console.log(result.join('\r'));
}

usernames(['Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston']
);