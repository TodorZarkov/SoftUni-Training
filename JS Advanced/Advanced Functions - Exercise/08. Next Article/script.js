function getArticleGenerator(articles) {
    let contentElement = document.getElementById('content');
    return showNext;
    function showNext() {
        let article = articles.shift();
        if(article === undefined){
            
            return;
        }
        let artcElement = document.createElement('article');
        artcElement.textContent= article;
        contentElement.appendChild(artcElement);
        
    }
}
