import numpy as np
import pandas as pd
import matplotlib.pyplot as pyplot

n_clusters=10

properties = ['a','b','c','d','e']

#remove all entries with empty properties
for prop in properties:
    mask=[]
    mask=data[np.all([mask, type(i)!=str for i in data[prop]],axis=0)]
used_data=data[mask]

#rescale everything into a number between 0 and 1
for prop in properties:
    eval(prop+'_scaled')=(used_data['prop']-np.min(used_data['prop']))/(np.max(used_data['prop'])-np.min(used_data['prop']))

cluster=[]
for i in range(n_clusters):
    cluster.append(np.random.rand(len(properties)))
