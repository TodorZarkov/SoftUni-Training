class OnlineShop {
    constructor(warehouseSpace) {
        this.warehouseSpace = warehouseSpace;
        this.products = [];
        this.sales = [];
    }

    loadingStore(product, quantity, spaceRequired) {
        if (this.warehouseSpace - spaceRequired < 0) {
            throw new Error("Not enough space in the warehouse.");
        }

        this.products.push({ product, quantity });
        this.warehouseSpace -= spaceRequired;
        return `The ${product} has been successfully delivered in the warehouse.`
    }

    quantityCheck(product, minimalQuantity) {
        let inProduct = this.products.find(p => p.product === product)
        if (!inProduct) {
            throw new Error(`There is no ${product} in the warehouse.`)
        }

        if (minimalQuantity <= 0) {
            throw new Error("The quantity cannot be zero or negative.");
        }

        if (minimalQuantity <= inProduct.quantity) {
            return `You have enough from product ${product}.`
        }

        let difference = minimalQuantity - inProduct.quantity;
        inProduct.quantity = minimalQuantity;
        return `You added ${difference} more from the ${product} products.`
    }

    sellProduct(product) {
        let inProduct = this.products.find(p => p.product === product)
        if (!inProduct) {
            throw new Error(`There is no ${product} in the warehouse.`)
        }

        inProduct.quantity--;
        this.sales.push({
            product:inProduct.product,
            quantity:1
        });
        
        return `The ${product} has been successfully sold.`
    }

    revision(){
        if(this.sales.length === 0) {
            throw new Error("There are no sales today!");
        }

        let result = `You sold ${this.sales.length} products today!\n`;
        result += "Products in the warehouse:\n";
        result += this.products.map(p=>`${p.product}-${p.quantity} more left`).join("\n");

        return result;
    }

}


const myOnlineShop = new OnlineShop(500)
console.log(myOnlineShop.loadingStore('headphones', 10, 200));
console.log(myOnlineShop.loadingStore('laptop', 5, 200));

console.log(myOnlineShop.quantityCheck('headphones', 10));
console.log(myOnlineShop.quantityCheck('laptop', 10));

console.log(myOnlineShop.sellProduct('headphones'));
console.log(myOnlineShop.sellProduct('laptop'));
console.log(myOnlineShop.revision());
