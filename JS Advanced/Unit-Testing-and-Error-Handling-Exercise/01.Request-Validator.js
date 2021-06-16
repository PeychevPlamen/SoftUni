function validator(input) {

    let requestObject = Object.entries(input);

    let validate = true;

    validateMethod(requestObject[0]);
    validateUri(requestObject[1]);
    validateVersion(requestObject[2]);
    validateMessage(requestObject[3]);

    return input;

    function validateMethod(entry) {

        let methods = ['GET', 'POST', 'DELETE', 'CONNECT'];

        if (entry === undefined) {

            validate = false;

        } else {

            let [key, value] = entry;

            if (key !== 'method' || !methods.includes(value)) {
                validate = false;
            };
        }
        if (!validate) {
            throw new Error('Invalid request header: Invalid Method');
        };

    }

    function validateUri(entry) {

        if (entry === undefined) {

            validate = false;

        } else {

            let [key, value] = entry;

            if (key !== 'uri' || value === '') {

                validate = false;
            }
            if (key === 'uri' && value !== '*' && value !== '') {

                const regex = /^[a-zA-Z0-9.]*$/;    // gm ??????

                validate = regex.test(value);
            };

        }
        if (!validate) {
            throw new Error('Invalid request header: Invalid URI');
        }
    }
    function validateVersion(entry) {

        let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

        if (entry === undefined) {

            validate = false;

        } else {

            let [key, value] = entry;

            if (key !== 'version' || !versions.includes(value)) {
                validate = false;
            }
        }
        if (!validate) {
            throw new Error('Invalid request header: Invalid Version');
        }

    };
    function validateMessage(entry) {

        if (entry === undefined) {

            validate = false;

        } else {

            let [key, value] = entry;

            if (key !== 'message') {
                validate = false;
            } else {
                const regex = /^[^<>\\&'"]*$/;
                validate = regex.test(value);
            }

        }
        if (!validate) {
            throw new Error('Invalid request header: Invalid Message');
        }

    };

}
console.log(validator({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}
));
console.log(validator({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
}
));