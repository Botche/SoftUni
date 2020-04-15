import models from '../models/index.js';

export default {
    get: {
        async home(ctx) {
            const token = sessionStorage.getItem('token');
            
            if (token) {
                const articles = await models.requester.get(`articles.json?auth=${token}`)
                if (articles) {
                    const javascriptArticles = [];
                    const csharpArticles = [];
                    const javaArticles = [];
                    const pythonArticles = [];

                    Object.keys(articles).forEach(key => {
                        articles[key].id = key;
                        if(articles[key].category.toLowerCase() === 'javascript'){
                            javascriptArticles.push(articles[key]);
                        } else if(articles[key].category.toLowerCase() === 'csharp'){
                            csharpArticles.push(articles[key]);
                        } else if(articles[key].category.toLowerCase() === 'java'){
                            javaArticles.push(articles[key]);
                        } else if(articles[key].category.toLowerCase() === 'python'){
                            pythonArticles.push(articles[key]);
                        }
                    });

                    ctx['javascriptArticles'] = javascriptArticles.sort((a, b) => b.title.localeCompare(a.title));
                    ctx['csharpArticles'] = csharpArticles.sort((a, b) => b.title.localeCompare(a.title));
                    ctx['javaArticles'] = javaArticles.sort((a, b) => b.title.localeCompare(a.title));
                    ctx['pythonArticles'] = pythonArticles.sort((a, b) => b.title.localeCompare(a.title));
                }
            }

            ctx.email = sessionStorage.getItem('email');
            ctx.isLoggedIn = !!sessionStorage.getItem('token');

            ctx.loadPartials({
                header: '../views/common/header.hbs',
                footer: '../views/common/footer.hbs'
            }).then(function () {
                this.partial('../views/home/home.hbs');
            })
        }
    }
}