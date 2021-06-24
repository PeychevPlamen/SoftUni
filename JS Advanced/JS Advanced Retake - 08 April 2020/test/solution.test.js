let { Repository } = require("../solution.js");
const { assert, expect } = require('chai');

describe("Tests …", () => {

    let repo = "";
    let properties = "";
    let entity = "";
    let entity2 = "";

    beforeEach(() => {
        properties = {
            name: "string",
            age: "number",
            birthday: "object",
        };
        repo = new Repository(properties);
        entity = { name: "stamat", age: 5, birthday: new Date(1998, 0, 7) };
        entity2 = { name: "stamat2", age: 5, birthday: new Date(1998, 0, 7) };

    });

    describe('Test getter ', () => {
        it('getter should work properly', () => {

            assert.equal(repo.count, 0);
        });
    });

    describe('Test add method', () => {
        it('add should work', () => {


            assert.equal(repo.add(entity), 0);
            assert.equal(repo.add(entity2), 1);
        });

        it('Test throw an error', () => {

            let anotherEntity = { names: 'Kolio Kolev', age: 10, birthday: new Date(1998, 0, 7) };


            expect(() => repo.add(anotherEntity)).to.throw(Error, `Property name is missing from the entity!`);

        });
    });

    describe('Test getId', () => {
        it('getId should work', () => {
            repo.add(entity);
            repo.add(entity2);

            expect(repo.getId(1)).to.deep.equal(entity2);
            expect(repo.getId(0)).to.deep.equal(entity);
        });

        it('Test getId should throw error', () => {
            repo.add(entity);
            repo.add(entity2);

            expect(() => repo.getId(-1)).to.throw(Error, `Entity with id: -1 does not exist!`);
            expect(() => repo.getId(16)).to.throw(Error, `Entity with id: 16 does not exist!`);
        });
    });

    describe('Test update', () => {
        it('Test update should work correct', () => {
            repo.add(entity);
            repo.add(entity2);

            let anotherEntity = { name: 'pesho', age: 99, birthday: new Date(1999, 0, 7) };
            repo.update(1, anotherEntity);
            expect(repo.getId(0)).to.deep.equal(entity);
            expect(repo.getId(1)).to.deep.equal(anotherEntity);

        });

        it('Test update trow an errors', () => {
            let anotherEntity = { names: 'Pesho', age: 10, birthday: new Date(1998, 0, 7) };

            repo.add(entity);
            repo.add(entity2);

            expect(() => repo.update(5, anotherEntity)).to.throw(Error, `Entity with id: 5 does not exist!`);
            expect(() => repo.update(1, anotherEntity)).to.throw(Error, `Property name is missing from the entity!`);

        });
    });

    describe('Test delete method', () => {
        it('Test delete method should work', () => {
            repo.add(entity);
            repo.add(entity2);

            repo.del(1);
            expect(repo.count).to.be.equal(1);
            expect(repo.getId(0)).to.deep.equal(entity);

        });

        it(' Test delete should throw an error', () => {
            repo.add(entity);
            repo.add(entity2);

            expect(() => repo.del(3)).to.throw(Error, `Entity with id: 3 does not exist!`);

        });
    });
});
