window.getCurrentLocation = async () => {
    return new Promise((resolve, reject) => {
        if (!navigator.geolocation) {
            reject("Geolocation not supported");
            return;
        }

        navigator.geolocation.getCurrentPosition(
            pos => {
                const coords = {
                    latitude: pos.coords.latitude,
                    longitude: pos.coords.longitude
                };
                resolve(coords);
            },
            err => reject(err.message)
        );
    });
};
