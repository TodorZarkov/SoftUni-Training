
const rootElement = document.getElementById('root');
const root = ReactDOM.createRoot(rootElement);

// const headingEelment = React.createElement('h1', {}, 'Hello from React');
// const secondHeadingElement = React.createElement('h2', {}, 'Second Heading');

// const headerElement = React.createElement('header', {}, headingEelment, secondHeadingElement);

// console.dir(rootElement);
// console.dir(root);

const headerElement = (
    <header>
        <h1>Hello from React</h1>
        <h2>Slogan here</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error ipsa deserunt optio tenetur est hic distinctio laborum perspiciatis repudiandae in?</p>
        <br />
        <button>Click!!!</button>
    </header>
    
);

root.render(headerElement);
