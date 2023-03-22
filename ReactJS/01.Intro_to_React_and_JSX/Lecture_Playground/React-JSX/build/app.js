
var rootElement = document.getElementById('root');
var root = ReactDOM.createRoot(rootElement);

// const headingEelment = React.createElement('h1', {}, 'Hello from React');
// const secondHeadingElement = React.createElement('h2', {}, 'Second Heading');

// const headerElement = React.createElement('header', {}, headingEelment, secondHeadingElement);

// console.dir(rootElement);
// console.dir(root);

var headerElement = React.createElement(
    'header',
    null,
    React.createElement(
        'h1',
        null,
        'Hello from React'
    ),
    React.createElement(
        'h2',
        null,
        'Slogan here'
    ),
    React.createElement(
        'p',
        null,
        'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error ipsa deserunt optio tenetur est hic distinctio laborum perspiciatis repudiandae in?'
    ),
    React.createElement('br', null),
    React.createElement(
        'button',
        null,
        'Click!!!'
    )
);

root.render(headerElement);