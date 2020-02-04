let result = (function result() {
    function add(firstVec, secondVec) {
        return [firstVec[0] + secondVec[0], firstVec[1] + secondVec[1]];
    }

    function multiply(firstVec, scalar) {
        return [firstVec[0] * scalar, firstVec[1] * scalar];
    }

    function length(firstVec) {
        return Math.sqrt(firstVec[0] ** 2 + firstVec[1] ** 2);
    }

    function dot(firstVec, secondVec) {
        return firstVec[0] * secondVec[0] + firstVec[1] * secondVec[1];
    }

    function cross(firstVec, secondVec) {
        return firstVec[0] * secondVec[1] - secondVec[0] * firstVec[1];
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    }
})();

console.log(result.add([5.43, -1], [1, 31]));