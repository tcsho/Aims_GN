//Version
var appversion='V1.00';

//Files to Cache
var files=[
'./',
'./index.html',
'./manifest',
]

self.addEventListener('install',event=>{
	event.waitUntil(
		caches.open(appversion)
		.then(cache=>{
			return cache.addAll(files)
			.catch(err=>{
				console.error('Error Adding Files to Cache',err);
			})
		})
		)
	console.info('SW Installed');
	self.skipWaiting();
})

//Activate
self.addEventListener('activate',event=>{
	event.waitUntil(
		caches.keys()
		.then(cacheNames=>{
			return Promise.all(
				cacheNames.map(cache=>{
					if(cache!==appversion)
					{
						console.info('Delete Old Cache',cache)
						return caches.delete(cache);
					}
				})
				)
		})
		)

	return self.clients.claim()
})

//Fetch
self.addEventListener('fetch',event=>{
	console.info('SW Fetch', event.request.url);

	event.respondWith(
		caches.match(event.request)
		.then(res=>{
			return res || fetch(event.request);
		})
		)

})